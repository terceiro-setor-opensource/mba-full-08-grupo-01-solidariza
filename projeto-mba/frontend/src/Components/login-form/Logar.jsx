import { useState } from "react";
import PropTypes from "prop-types"; // Importa PropTypes
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "./loginForm.css";

const LoginForm = ({ onSubmit }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ username, password });
  };

  return (
    <div className="login-form">
      <form className="form" onSubmit={handleSubmit}>
        <h1>FAÇA SEU LOGIN</h1>
        <div className="input-field">
          <h4 className="nomeField">E-MAIL</h4>
          <input
            type="email"
            placeholder="Digite seu e-mail"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="input-field">
          <h4 className="nomeField">SENHA</h4>
          <input
            type="password"
            placeholder="Digite sua senha"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="naoPossuiCadastro">
          <h5>
            NÃO POSSUI CADASTRO? FAÇA SEU &nbsp;
            <a href="/">CADASTRO</a>
          </h5>
        </div>

        <div className="btnLogin">
          <button type="submit">LOGIN</button>
        </div>
      </form>
      <ToastContainer />
    </div>
  );
};

// Validação das props
LoginForm.propTypes = {
  onSubmit: PropTypes.func.isRequired, // onSubmit deve ser uma função e é obrigatório
};

export default LoginForm;