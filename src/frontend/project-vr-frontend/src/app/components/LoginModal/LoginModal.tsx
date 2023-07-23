import { LoggedUser } from "@/app/pages/SearchUsers/SearchUsers";
import {
  Button,
  Modal,
  Text,
  Input,
  Row,
  Checkbox,
  SimpleColors,
} from "@nextui-org/react";
import { request } from "http";
import { useState } from "react";

interface LoginModalProps {
  visible: boolean;
  openHandler: () => void;
  closeHandler: () => void;
  setLoggedUser: (user: LoggedUser) => void;
}

export interface LoginResponse {
  userGuid: string;
  username: string;
  avatar: string;
}

export interface LoginRequest {
  username: string;
}

export default function LoginModal(props: LoginModalProps) {
  const {
    visible,
    openHandler,
    closeHandler,
    setLoggedUser: setIsLoggedIn,
  } = props;

  const login = async (requestBody: LoginRequest) => {
    try {
      const data = await fetch("https://localhost:8080/api/login", {
        method: "post",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
      });
      if (data.status == 404) {
        setLoginErrorMessage("User doesnt exist");
        setLoginLabelColor("error");
        return;
      }
      setLoginLabelColor("primary");
      setLoginErrorMessage("");
      const user: LoginResponse = await data.json();
      document.cookie = `logged-user=${JSON.stringify(user)}`;
      closeHandler();
      setIsLoggedIn(user);
    } catch (error) {
      setLoginErrorMessage("Unknown error");
      setLoginLabelColor("error");
    }
  };
  const [enteredLogin, setEnteredLogin] = useState("");
  const [loginLabelColor, setLoginLabelColor] =
    useState<SimpleColors>("primary");
  const [loginErrorMessage, setLoginErrorMessage] = useState("");
  return (
    <div>
      <Modal
        closeButton
        blur
        aria-labelledby="login-modal-title"
        open={visible}
        onClose={closeHandler}
      >
        <Modal.Header>
          <Text id="login-modal-title" size={36}>
            Sign in
          </Text>
        </Modal.Header>
        <Modal.Body>
          <Input
            clearable
            bordered
            fullWidth
            color={loginLabelColor}
            label={loginErrorMessage}
            size="lg"
            placeholder="Username"
            value={enteredLogin}
            onChange={event => {
              setEnteredLogin(event.target.value);
            }}
          />
          <Input
            clearable
            bordered
            fullWidth
            color="primary"
            size="lg"
            placeholder="Password"
            type="password"
          />
          <Row justify="space-between">
            <Checkbox>
              <Text size={14}>Remember me</Text>
            </Checkbox>
            <Text size={14}>Forgot password ?</Text>
          </Row>
        </Modal.Body>
        <Modal.Footer>
          <Button auto flat color="error" onPress={closeHandler}>
            Close
          </Button>
          <Button auto onPress={() => login({ username: enteredLogin })}>
            Sign in
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
