import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import LoginForm from "../Components/login-form/Logar"
import Logo from "../Components/logo/logo"
import { authUser } from "../auth/authUser"; 
import style from "./styles/Login.module.css"

const LoginPage = () => {
  const navigate = useNavigate();

  const handleLogin = async ({ username, password }) => {
    if (!username || !password) {
      toast.warn("Por favor, preencha todos os campos.");
      return;
    }

    try {
      const response = await authUser(username, password);
      
      if (response.success) {
        toast.success("Login realizado com sucesso!");
        
        // Aguarda 4 segundos antes de navegar
        setTimeout(() => {
          navigate("/");
        }, 4000);
      } else {
        toast.error(response.message);
      }
    } catch (error) {
      toast.error("Erro ao realizar login. Tente novamente.");
    }
  };

  return (
    <div className={style.container}>
      <Logo />
      <LoginForm onSubmit={handleLogin} />
    </div>
  );
};

export default LoginPage;