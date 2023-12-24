import { login } from "@/http/authApi";
import { LoggedUser } from "@/types/commonTypes";
import { LOGGED_USER_COOKIE_KEY } from "@/utils/consts";
import { setCookieOfType } from "@/utils/cookies";
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
import { useState } from "react";

interface LoginModalProps {
  isOpen: boolean;
  onOpenChange: (isOpen: boolean) => void;
  setLoggedUser: (user: LoggedUser) => void;
}
export default function LoginModal(props: LoginModalProps) {
  const { isOpen, onOpenChange, setLoggedUser } = props;

  const onLogin = async (username: string) => {
    try {
      const { statusCode, message, data: user } = await login(username);
      if (statusCode == 404) {
        setLoginErrorMessage("User doesnt exist");
        setLoginLabelColor("danger");
        return;
      }
      setLoginLabelColor("primary");
      setLoginErrorMessage("");
      setCookieOfType(LOGGED_USER_COOKIE_KEY, user);
      onOpenChange(false);
      setLoggedUser(user);
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
                <Checkbox>
                  <p>Remember me</p>
                </Checkbox>
                <p>Forgot password ?</p>
              </ModalBody>
              <ModalFooter>
                <Button variant="flat" color="danger" onPress={onClose}>
                  Close
                </Button>
                <Button onPress={() => onLogin(enteredLogin)}>Sign in</Button>
              </ModalFooter>
            </>
          )}
        </ModalContent>
      </Modal>
    </div>
  );
}
