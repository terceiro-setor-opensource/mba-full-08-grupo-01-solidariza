import { Outlet } from "react-router-dom";
import Header from "../Components/header/Header";
import "./styles/Home.css";
function Home() {
  return (
    <div className="home">
      <Header />

      <div className="outlet">
        <Outlet />
      </div>
    </div>
  );
}

export default Home;
