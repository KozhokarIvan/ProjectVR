using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using ProjectVR.BusinessLogic.Services;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models;
using Xunit;

namespace ProjectVR.Tests.Unit.BusinessLogic;

public class FriendsServiceTests
{
    [Fact(DisplayName = "Успешно отправляет заявку в друзья")]
    public void SendFriendRequestToOtherUser_ShouldSendRequest()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        Friend? friendEntry = null;

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(userGuid, friendGuid).Returns(Task.FromResult(friendEntry));
        friendsRepository.GetRequestByUserGuids(friendGuid, userGuid).Returns(Task.FromResult(friendEntry));
        friendsRepository.CreateRequest(userGuid, friendGuid).Returns(Task.CompletedTask);

        //act
        var result = friendsService.SendFriendRequest(userGuid, friendGuid).Result;

        //assert
        friendsRepository.Received(1).GetRequestByUserGuids(userGuid, friendGuid);
        friendsRepository.Received(1).CreateRequest(userGuid, friendGuid);

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Не отправляет заявку в друзья, если идентичная заявка уже существует")]
    public void SendFriendRequestWhenAlreadyExists_ShouldNotSendRequest()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        var friendEntry = new Friend();

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(userGuid, friendGuid)!.Returns(Task.FromResult(friendEntry));
        friendsRepository.GetRequestByUserGuids(friendGuid, userGuid)!.Returns(Task.FromResult(friendEntry));
        friendsRepository.CreateRequest(userGuid, friendGuid).Returns(Task.CompletedTask);

        //act
        var result = friendsService.SendFriendRequest(userGuid, friendGuid).Result;

        //assert
        friendsRepository.Received(1).GetRequestByUserGuids(userGuid, friendGuid);
        friendsRepository.DidNotReceiveWithAnyArgs().CreateRequest(userGuid, friendGuid);

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Не отправляет заявку в друзья самому себе")]
    public void SendFriendRequestToSelf_ShouldNotSendRequest()
    {
        //arrange
        var selfGuid = Guid.NewGuid();
        Friend? friendEntry = null;

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(selfGuid, selfGuid).Returns(Task.FromResult(friendEntry));
        friendsRepository.CreateRequest(selfGuid, selfGuid).Returns(Task.CompletedTask);

        //act
        var result = friendsService.SendFriendRequest(selfGuid, selfGuid).Result;

        //assert
        friendsRepository.DidNotReceive().GetRequestByUserGuids(selfGuid, selfGuid);
        friendsRepository.DidNotReceiveWithAnyArgs().CreateRequest(selfGuid, selfGuid);

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Успешно принимает заявку в друзья от другого пользователя")]
    public void AcceptExistingFriendRequestFromOtherUserToYourself_ShouldAccept()
    {
        //arrange
        var senderUserGuid = Guid.NewGuid();
        var accepterUserGuid = Guid.NewGuid();
        var friend = new Friend
        {
            Id = 1,
            SenderUserGuid = senderUserGuid,
            AccepterUserGuid = accepterUserGuid
        };

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.AddAcceptedAtDate(friend.Id, Arg.Any<DateTimeOffset>()).Returns(Task.FromResult(true));

        //act
        var result = friendsService
            .AcceptFriendRequest(accepterUserGuid, senderUserGuid)
            .Result;

        //assert
        friendsRepository.Received(1).GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid);
        friendsRepository.Received(1).AddAcceptedAtDate(friend.Id, Arg.Any<DateTimeOffset>());

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Не принимает исходящую заявку от себя же для другого пользователя")]
    public void AcceptExistingFriendRequestFromYourselfToOtherUser_ShouldNotAccept()
    {
        //arrange
        var senderUserGuid = Guid.NewGuid();
        var accepterUserGuid = Guid.NewGuid();
        var friend = new Friend
        {
            Id = 1,
            SenderUserGuid = accepterUserGuid,
            AccepterUserGuid = senderUserGuid
        };

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.AddAcceptedAtDate(friend.Id, Arg.Any<DateTimeOffset>()).Returns(Task.FromResult(true));

        //act
        var result = friendsService
            .AcceptFriendRequest(accepterUserGuid, senderUserGuid)
            .Result;

        //assert
        friendsRepository.Received(1).GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid);
        friendsRepository.DidNotReceiveWithAnyArgs().AddAcceptedAtDate(friend.Id, Arg.Any<DateTimeOffset>());

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Не принимает несуществующую заявку в друзья")]
    public void AcceptNonExistingFriendRequest_ShouldNotAccept()
    {
        //arrange
        var senderUserGuid = Guid.NewGuid();
        var accepterUserGuid = Guid.NewGuid();
        Friend? friend = null;

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.AddAcceptedAtDate(default, default).Returns(Task.FromResult(false));

        //act
        var result = friendsService
            .AcceptFriendRequest(accepterUserGuid, senderUserGuid)
            .Result;

        //assert
        friendsRepository.Received(1).GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid);
        friendsRepository.DidNotReceiveWithAnyArgs().AddAcceptedAtDate(Arg.Any<int>(), Arg.Any<DateTimeOffset>());

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Отклоняет входящую заявку от другого пользователя")]
    public void DeclineExistingFriendRequestFromOtherPersonToYourself_ShouldDecline()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        var friend = new Friend
        {
            Id = 1,
            SenderUserGuid = friendGuid,
            AccepterUserGuid = userGuid
        };

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(userGuid, friendGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.GetRequestByUserGuids(friendGuid, userGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.DeleteRequest(friend.Id).Returns(Task.FromResult(true));

        //act
        var result = friendsService
            .DeclineFriendRequest(friendGuid, userGuid)
            .Result;

        //assert
        friendsRepository.Received(1)
            .GetRequestByUserGuids(
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid),
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid));
        friendsRepository.Received(1).DeleteRequest(friend.Id);

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Отменяет исходящую заявку от себя для другого пользователя")]
    public void DeclineExistingFriendRequestFromYourselfToOtherPerson_ShouldDecline()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        var friend = new Friend
        {
            Id = 1,
            SenderUserGuid = userGuid,
            AccepterUserGuid = friendGuid
        };

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(userGuid, friendGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.GetRequestByUserGuids(friendGuid, userGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.DeleteRequest(friend.Id).Returns(Task.FromResult(true));

        //act
        var result = friendsService
            .DeclineFriendRequest(userGuid, friendGuid)
            .Result;

        //assert
        friendsRepository.Received(1)
            .GetRequestByUserGuids(
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid),
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid));
        friendsRepository.Received(1).DeleteRequest(friend.Id);

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Не отклоняет не существующую заявку")]
    public void DeclineNonExistingRequest_ShouldNotDecline()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        Friend? friend = null;

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetExactRequestByUsersGuids(userGuid, friendGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.DeleteRequest(default).Returns(false);

        //act
        var result = friendsService
            .DeclineFriendRequest(friendGuid, userGuid)
            .Result;

        //assert
        friendsRepository.Received(1)
            .GetRequestByUserGuids(
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid),
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid));
        friendsRepository.DidNotReceiveWithAnyArgs().DeleteRequest(Arg.Any<int>());

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Удаляет друга из списка друзей")]
    public void DeleteExistingFriend_ShouldDelete()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        var friend = new Friend
        {
            Id = 1,
            SenderUserGuid = userGuid,
            AccepterUserGuid = friendGuid
        };

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetRequestByUserGuids(userGuid, friendGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.GetRequestByUserGuids(friendGuid, userGuid)!.Returns(
            Task.FromResult(friend));
        friendsRepository.ClearAcceptedAtDate(friend.Id).Returns(Task.FromResult(true));

        //act
        var result = friendsService
            .DeleteFriend(friendGuid, userGuid)
            .Result;

        //assert
        friendsRepository.Received(1)
            .GetRequestByUserGuids(
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid),
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid));
        friendsRepository.Received(1).ClearAcceptedAtDate(friend.Id);

        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Не удаляет из друзей пользователя, которого и так нет в списке друзей")]
    public void DeleteNonExistingFriend_ShouldNotDelete()
    {
        //arrange
        var userGuid = Guid.NewGuid();
        var friendGuid = Guid.NewGuid();
        Friend? friend = null;

        var friendsRepository = Substitute.For<IRequestsRepository>();
        var friendsService = new FriendsService(friendsRepository);
        friendsRepository.GetExactRequestByUsersGuids(userGuid, friendGuid)!.Returns(
            Task.FromResult(friend));

        //act
        var result = friendsService
            .DeleteFriend(friendGuid, userGuid)
            .Result;

        //assert
        friendsRepository.Received(1)
            .GetRequestByUserGuids(
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid),
                Arg.Is<Guid>(guid => guid == friendGuid || guid == userGuid));
        friendsRepository.DidNotReceiveWithAnyArgs().ClearAcceptedAtDate(Arg.Any<int>());

        result.Should().BeFalse();
    }
}