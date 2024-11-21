import { Link, useLocation, useNavigate } from "react-router-dom";
import logo from "../../assets/header-logo.svg";
import "./Header.css";

function Header() {
  const location = useLocation();
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("token");
    console.log("token removido");
    navigate("/login");
  };

  return (
    <div className="header">
      <img src={logo} alt="logo" />
      <div className="buttons">
        <Link to="/" className={`button ${location.pathname === "/" ? "active" : ""}`}>
          PRODUTO
        </Link>
        <Link to="/doadores-list" className={`button ${location.pathname === "/doadores-list" ? "active" : ""}`}>
          DOADORES
        </Link>
        <Link to="/estoque" className={`button ${location.pathname === "/estoque" ? "active" : ""}`}>
          ESTOQUE
        </Link>
        <Link to="/abrigo-list" className={`button ${location.pathname === "/abrigo-list" ? "active" : ""}`}>
          ABRIGO
        </Link>
      </div>
      <div>
        <button  className="btn" onClick={handleLogout}>Sair
          <i className="fa-solid fa-house"></i>
        </button>
        
      </div>
    </div>
  );
}

export default Header;
