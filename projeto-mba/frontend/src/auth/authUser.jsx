import axios from "axios";

export const authUser = async (username, password) => {
  const payload = { username, password };

  try {
    const response = await axios.post("https://localhost:7289/api/auth/login", payload);

    if (response.status === 200) {
      localStorage.setItem("token", response.data.token);
      axios.defaults.headers.common["Authorization"] = `Bearer ${response.data.token}`;

      return { success: true };
    }
    
    return { success: false, message: "Erro ao realizar login. Verifique suas credenciais." };

  } catch (error) {
    if (error.response) {
      const { status, data } = error.response;

      if (status === 400 && data.errors) {
        if (data.errors.Username && data.errors.Username.includes("não cadastrado")) {
          return { success: false, message: "E-mail não cadastrado." };
        } else if (data.errors.Password && data.errors.Password.includes("incorreta")) {
          return { success: false, message: "Senha incorreta." };
        }
      } else if (status === 401) {
        return { success: false, message: "Credenciais inválidas." };
      }
    }

    return { success: false, message: "Erro ao realizar login. Tente novamente." };
  }
};
