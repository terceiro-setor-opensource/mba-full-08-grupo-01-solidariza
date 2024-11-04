
import style from "./styles/ErrorPage.module.css"

const ErrorPage = () => {
  return (
    <div className={style.container}>
      <h1 className={style.notFoundTitle}>404</h1>
      <p className={style.notFoundMessage}>Página não encontrada</p>
      <a href="/" className={style.notFoundLink}>Voltar para a Home</a>
    </div>
  );
};

export default ErrorPage;
