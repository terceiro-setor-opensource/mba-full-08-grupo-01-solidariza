import { useState } from "react";
import "./cadastroAbrigo.css";
import axios from "axios";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

const CadastroAbrigo = ({ onSelect, tipoCadastro }) => {
  const [useremail, setUseremail] = useState("");
  const [usercnpj, setUsercnpj] = useState("");
  const [userpassword, setUserpassword] = useState("");
  const [userendereco, setUserendereco] = useState("");
  const [usercidade, setUsercidade] = useState("");
  const [userrazaosocial, setUserrazaosocial] = useState(""); // Campo RazaoSocial

  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validações simples para verificar se todos os campos estão preenchidos
    if (
      !useremail ||
      !usercnpj ||
      !userpassword ||
      !usercidade ||
      !userendereco ||
      !userrazaosocial
    ) {
      toast.warn("Por favor, preencha todos os campos.");
      return;
    }

    // Valida o CNPJ
    const validarCNPJ = (cnpj) => {
      cnpj = cnpj.replace(/[^\d]+/g, '');
      if (cnpj.length !== 14) return false;
      if (/^(\d)\1+$/.test(cnpj)) return false;

      let tamanho = cnpj.length - 2;
      let numeros = cnpj.substring(0, tamanho);
      let digitos = cnpj.substring(tamanho);
      let soma = 0;
      let pos = tamanho - 7;

      for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
      }

      let resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
      if (resultado != digitos.charAt(0)) return false;

      tamanho = tamanho + 1;
      numeros = cnpj.substring(0, tamanho);
      soma = 0;
      pos = tamanho - 7;

      for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
      }

      resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
      return resultado == digitos.charAt(1);
    };

    // Valida a senha
    const validarSenha = (senha) => {
      const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
      return regex.test(senha);
    };

    if (!validarCNPJ(usercnpj)) {
      toast.warn("CNPJ inválido.");
      return;
    }

    if (!validarSenha(userpassword)) {
      toast.warn("Senha deve ter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula e um número.");
      return;
    }

    // Mapeamento de tipo de usuário para o que o back-end espera
    const tipoUsuarioValue = tipoCadastro === "abrigo" ? 0 : 1;

    const payload = {
      cnpjCpf: usercnpj,
      email: useremail,
      senha: userpassword,
      tipoUsuario: tipoUsuarioValue,
      cidadeEstado: usercidade,
      endereco: userendereco,
      razaoSocial: userrazaosocial,
    };

    try {
      const response = await axios.post(
        "https://localhost:7289/api/usuario/new",
        payload
      );

      if (response.status === 201 || response.status === 200) {
        toast.success("Abrigo cadastrado com sucesso!");
        setTimeout(() => {
          navigate("/login");
        }, 3000);
      } else {
        toast.error("Erro ao cadastrar abrigo. Tente novamente.");
      }
    } catch (error) {
      if (error.response) {
        toast.error(`Erro: ${error.response.data.message || "Erro ao cadastrar abrigo."}`);
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
          <h4 className="nomeField">RAZAO SOCIAL</h4>
          <input
            type="text"
            placeholder="Digite a razão social"
            value={userrazaosocial}
            onChange={(e) => setUserrazaosocial(e.target.value)}
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
          <h4 className="nomeField">CNPJ</h4>
          <input
            type="text"
            placeholder="Digite seu CNPJ"
            value={usercnpj}
            onChange={(e) => setUsercnpj(e.target.value)}
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
        <div className="input-field">
          <h4 className="nomeField">ENDEREÇO</h4>
          <input
            type="text"
            placeholder="Digite seu endereço"
            value={userendereco}
            onChange={(e) => setUserendereco(e.target.value)}
          />
        </div>
        <div className="input-field">
          <h4 className="nomeField">CIDADE</h4>
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
      <ToastContainer /> {/* Adiciona o ToastContainer aqui */}
    </div>
  );
};

CadastroAbrigo.propTypes = {
  onSelect: PropTypes.func.isRequired,
  tipoCadastro: PropTypes.string.isRequired,
};

export default CadastroAbrigo;
