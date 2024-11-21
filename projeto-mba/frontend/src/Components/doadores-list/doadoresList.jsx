import icon from "../../assets/image.png";
import "./doadoresList.css";


const DoadoresList = () => {
  const lista = [1, 2, 3, 4, 5, 6, 7, 8];

  return (
    <div className="doadores-list">
      <h1>DOADORES: {lista.length}</h1>
      

      <div className="doadores-list-container">
        {lista.map((item) => (
          <div className="doadores-list-item-info" key={item}>
            <img className="img-persona" src={icon} alt="" />
            <h2>Douglas Luiz</h2>
            <p>123.456.789-00</p>
            <p>meuemail@gmail.com</p>
            <h3>Fez uma doação de:</h3>
            <p>5 pacotes de arroz</p>
            

            <div className="doadores-list-item-detail">
              <p>20/10/2024</p>
              <h4>Recebido</h4>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default DoadoresList;
