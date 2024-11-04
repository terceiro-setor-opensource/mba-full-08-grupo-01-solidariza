import { useState } from "react";
import "./toggleStatus.css";

const ToggleStatus = () => {
  const [received, setReceived] = useState(false);

  const toggleReceived = () => {
    setReceived(!received);
  };

  return (
    <div
      style={{
        width: "100px",
        height: "50px",
        backgroundColor: received ? "red" : "gray",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        color: "white",
        cursor: "pointer",
        borderRadius: "5px",
        transition: "background-color 0.3s ease",
      }}
      onClick={toggleReceived}
    >
      {received ? "Recebido" : "Não Recebido"}
    </div>
  );
};

export default ToggleStatus;
