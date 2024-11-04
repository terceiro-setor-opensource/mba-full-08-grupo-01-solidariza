import { useState } from "react";
import PropTypes from "prop-types";
import axios from "axios";
import "./cadastroDoador.css";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useNavigate } from "react-router-dom";

const CadastroDoador = ({ onSelect, tipoCadastro }) => {
  const [username, setUsername] = useState("");
  const [useremail, setUseremail] = useState("");
  const [usercpf, setUsercpf] = useState("");
  const [userpassword, setUserpassword] = useState("");
  const [usergenero, setUsergenero] = useState("");
  const [usercidade, setUsercidade] = useState("");
  const [userendereco, setUserendereco] = useState("");

  const navigate = useNavigate();

  const validarCPF = (cpf) => {
    cpf = cpf.replace(/[^\d]+/g, ""); 
    if (cpf.length !== 11 || /^(\d)\1{10}$/.test(cpf)) return false;

    let soma = 0;
    let resto;

  
    for (let i = 1; i <= 9; i++) {
      soma += parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }
    resto = (soma * 10) % 11;
    if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf.substring(9, 10))) return false;

    soma = 0;
    for (let i = 1; i <= 10; i++) {
      soma += parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }
    resto = (soma * 10) % 11;
    if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf.substring(10, 11))) return false;

    return true;
  };

//colinha rsrsrs -> (?=.*[a-z]) -> pelo menos uma letra minúscula
// (?=.*[A-Z]) -> || letra maiúscula 
// (?=.*\d) ->|| um  número
// (?=.*[@$!%*?&])-> || um caractere especial. Aqui incluímos alguns dos símbolos mais comuns, como @, $, !, %, *, ?, e &. (aqui preciso melhorar pq pode dar xabu)
// [A-Za-z\d@$!%*?&]{8,}-> A senha deve ter pelo menos 8 caracteres, e pode conter letras maiúsculas, minúsculas, dígitos e os caracteres especiais permitidos.


  const validarSenha = (senha) => {

    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return regex.test(senha);
  };
  

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validação dos campos vazios
    if (
      !username ||
      !useremail ||
      !usercpf ||
      !userpassword ||
      !usergenero ||
      !usercidade ||
      !userendereco
    ) {
      toast.warn("Por favor, preencha todos os campos.");
      return;
    }

    // Validação do CPF
    if (!validarCPF(usercpf)) {
      toast.warn("CPF inválido.");
      return;
    }

    // Validação da senha
    if (!validarSenha(userpassword)) {
      toast.warn(
        "Senha deve ter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula e um número."
      );
      return;
    }

    // Definindo o valor de tipo de usuário
    const tipoUsuarioValue = tipoCadastro === "doador" ? 1 : 0;

    // Criando o payload para o envio
    const payload = {
      cnpjCpf: usercpf,
      email: useremail,
      senha: userpassword,
      tipoUsuario: tipoUsuarioValue,
      genero: parseInt(usergenero),
      nome: username,
      cidadeEstado: usercidade,
      endereco: userendereco,
    };

    try {
      const response = await axios.post(
        "https://localhost:7289/api/usuario/new",
        payload
      );

      if (response.status === 201 || response.status === 200) {
        toast.success("Usuário cadastrado com sucesso!");
        setTimeout(() => {
          navigate("/login");
        }, 3000);
      } else {
        toast.error("Erro ao cadastrar usuário. Tente novamente.");
      }
    } catch (error) {
      if (error.response) {
        toast.error(
          `Erro: ${error.response.data.message || "Erro ao cadastrar usuário."}`
        );
      } else if (error.request) {
        toast.error("Sem resposta do servidor. Verifique sua conexão.");
      } else {
        toast.error("Erro ao configurar a requisição. Tente novamente.");
      }
    }
  };

  return (
    <div className="cadastro-form">
      <form className="form" onSubmit={handleSubmit}>
        <h1>FAÇA O SEU CADASTRO PARA RECEBER OU REALIZAR UMA DOAÇÃO!</h1>
        <div>
          <h3>SELECIONE O SEU TIPO:</h3>
          <div className="btnDoadorOrAbrigo">
            <button
              type="button"
              className={tipoCadastro === "doador" ? "selected" : ""}
              onClick={() => onSelect("doador")}
            >
              DOADOR
            </button>
            <button
              type="button"
              className={tipoCadastro === "abrigo" ? "selected" : ""}
              onClick={() => onSelect("abrigo")}
            >
              ABRIGO
            </button>
          </div>
        </div>
        <br />
        <div className="input-field">
          <h4 className="nomeField">NOME</h4>
          <input
            type="text"
            placeholder="Digite seu nome"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="input-field">
          <h4 className="nomeField">E-MAIL</h4>
          <input
            type="email"
            placeholder="Digite seu e-mail"
            value={useremail}
            onChange={(e) => setUseremail(e.target.value)}
          />
        </div>
        <div className="input-field">
          <h4 className="nomeField">CPF</h4>
          <input
            type="text"
            placeholder="Digite seu CPF"
            value={usercpf}
            onChange={(e) => setUsercpf(e.target.value)}
          />
        </div>
        <div className="input-field">
          <h4 className="nomeField">SENHA</h4>
          <input
            type="password"
            placeholder="Digite sua senha"
            value={userpassword}
            onChange={(e) => setUserpassword(e.target.value)}
          />
        </div>
        <div className="input-field-select">
          <h4 className="nomeField-select">GÊNERO</h4>
          <select
            value={usergenero}
            onChange={(e) => setUsergenero(e.target.value)}
          >
            <option value="">Selecione o gênero</option>
            <option value="0">Masculino</option>
            <option value="1">Feminino</option>
            <option value="2">Prefiro não dizer</option>
          </select>
        </div>
        <div className="input-field-endereco">
          <h4 className="nomeField">ENDEREÇO</h4>
        </div>
        <div className="endereco">
          <input
            type="text"
            placeholder="Digite seu endereço"
            value={userendereco}
            onChange={(e) => setUserendereco(e.target.value)}
          />
          <input
            type="text"
            placeholder="Digite sua cidade"
            value={usercidade}
            onChange={(e) => setUsercidade(e.target.value)}
          />
        </div>
        <div className="possuiCadastro">
          <h5>
            JÁ POSSUI CADASTRO?&nbsp;
            <a href="/login">FAÇA LOGIN</a>
          </h5>
        </div>
        <div className="btnCadastrar">
          <button type="submit">CADASTRAR</button>
        </div>
      </form>
      <ToastContainer />
    </div>
  );
};

CadastroDoador.propTypes = {
  onSelect: PropTypes.func.isRequired,
  tipoCadastro: PropTypes.string.isRequired,
};

export default CadastroDoador;
