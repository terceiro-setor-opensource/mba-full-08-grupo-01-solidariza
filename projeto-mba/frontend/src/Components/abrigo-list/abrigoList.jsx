import icon from "../../assets/th.png";
import "./abrigoList.css";

const AbrigoList = () => {
    const lista = [1, 2, 3, 4, 5, 6, 7, 8];

    return (
        <div className="abrigo-list">
              <h1>DOAÇÕES SOLICITADAS: {lista.length}</h1>

            <div className="abrigo-list-container">
                {lista.map((item) => (
                    <div className="abrigo-list-item-info" key={item}>
                        <img className="img-talher" src={icon} alt="" />
                        <h2>Arroz</h2>
                        <p>5 pacotes</p><br/>
                        <h4>Prioridade:</h4>
                        <h3>Alta</h3>


                        <div className="abrigo-list-item-detail">
                            <p>29/10/2024</p>
                            <h4></h4>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default AbrigoList;
