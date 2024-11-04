import { useState } from "react";
import CadastroAbrigo from "../Components/abrigo/cadastroAbrigo";
import CadastroDoador from "../Components/doador/cadastroDoador";
import Logo from "../Components/logo/logo";
import styles from "./styles/Home.module.css";

function SignIn() {
  const [tipoCadastro, setTipoCadastro] = useState("doador");

  const handleSelect = (tipo) => {
    setTipoCadastro(tipo);
  };

  return (
    <div className={styles.container}>
      <Logo />

      {tipoCadastro === "doador" ? (
        <CadastroDoador onSelect={handleSelect} tipoCadastro={tipoCadastro} />
      ) : (
        <CadastroAbrigo onSelect={handleSelect} tipoCadastro={tipoCadastro} />
      )}
    </div>
  );
}

export default SignIn;
