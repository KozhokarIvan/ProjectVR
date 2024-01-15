import { useAppDispatch, useAppSelector } from "@/hooks/redux";
import { login } from "@/http/authApi";
import { setUser } from "@/redux/features/user";
import { selectLoginInfo } from "@/redux/features/user/selector";
import { LOGGED_USER_STORAGE_KEY } from "@/utils/consts";
import { setLocalStorageItem } from "@/utils/local-storage";
import {
  Button,
  Modal,
  Input,
  Checkbox,
  ModalHeader,
  ModalBody,
  ModalFooter,
  ModalContent,
} from "@nextui-org/react";
import React from "react";
import { useState } from "react";

interface LoginModalProps {
  isOpen: boolean;
  onOpenChange: (isOpen: boolean) => void;
}
export default function LoginModal(props: LoginModalProps) {
  const { isOpen, onOpenChange } = props;
  const [isRememberMe, setIsRememberMe] = React.useState(false);
  const dispatch = useAppDispatch();
  const selectedUser = useAppSelector(state => selectLoginInfo(state));
  const handleLogin = async (username: string) => {
    try {
      const { statusCode, message, data: user } = await login(username);
      if (statusCode == 404) {
        setLoginErrorMessage("User doesnt exist");
        setLoginLabelColor("danger");
        return;
      }
      dispatch(setUser(user));
      if (isRememberMe) {
        setLocalStorageItem(LOGGED_USER_STORAGE_KEY, user);
      }
      setLoginLabelColor("primary");
      setLoginErrorMessage("");
      setEnteredLogin("");
      setEnteredPassword("");
      onOpenChange(false);
    } catch (error) {
      setLoginErrorMessage("Unknown error");
      setLoginLabelColor("danger");
    }
  };
  const [enteredLogin, setEnteredLogin] = useState("");
  const [enteredPassword, setEnteredPassword] = useState("");
  const [loginLabelColor, setLoginLabelColor] = useState<"primary" | "danger">(
    "primary"
  );
  const [loginErrorMessage, setLoginErrorMessage] = useState("");
  return (
    <div>
      <Modal
        isOpen={isOpen}
        onOpenChange={onOpenChange}
        closeButton
        backdrop="blur"
        aria-labelledby="login-modal-title"
      >
        <ModalContent>
          {onClose => (
            <>
              <ModalHeader>
                <p id="login-modal-title">Sign in</p>
              </ModalHeader>
              <ModalBody>
                <Input
                  isClearable
                  variant="bordered"
                  fullWidth
                  color={loginLabelColor}
                  label={loginErrorMessage}
                  size="lg"
                  placeholder="Username"
                  value={enteredLogin}
                  onChange={event => {
                    setEnteredLogin(event.target.value);
                  }}
                  onClear={() => setEnteredLogin("")}
                />
                <Input
                  isClearable
                  variant="bordered"
                  fullWidth
                  color="primary"
                  size="lg"
                  placeholder="Password"
                  type="password"
                  value={enteredPassword}
                  onChange={event => {
                    setEnteredPassword(event.target.value);
                  }}
                  onClear={() => {
                    setEnteredPassword("");
                  }}
                />
                <Checkbox
                  defaultChecked={isRememberMe}
                  onValueChange={setIsRememberMe}
                >
                  <p>Remember me</p>
                </Checkbox>
                <p>Forgot password ?</p>
              </ModalBody>
              <ModalFooter>
                <Button variant="flat" color="danger" onPress={onClose}>
                  Close
                </Button>
                <Button onPress={() => handleLogin(enteredLogin)}>
                  Sign in
                </Button>
              </ModalFooter>
            </>
          )}
        </ModalContent>
      </Modal>
    </div>
  );
}
