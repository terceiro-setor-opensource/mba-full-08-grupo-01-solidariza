import "./modalFilter.css"
import imagen from "../../assets/tl.png"
import React from 'react'

export default function ModalFilter({ isOpen, setOpenModalFilter, openModalFilter}) {

    if (isOpen) {
        return (

            <div className="background-modal">
                <div className="conteudo-modal">
                    <div className="content-tittle">
                        <div className="header-modal">
                            <h2 className="tittle-modal">FILTRAR    </h2>
                            <p onClick={setOpenModalFilter} className="subtittle-modal">x</p>
                        </div>
                    </div>

                    <div className="info-modalFilter">
                        <div className="input-produto">
                            <label>PRODUTO:
                                <input>
                                </input> 
                            </label>
                        </div>
                        <div className="select-info">
                            <label>QUANTIDADE: 
                                <select name="" id="" >
                                    <option value="">Defina a quantidade</option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                </select>
                            </label>
                            <label>PRIORIDADE: 
                            <select name="" id="" >
                                    <option value="">Defina a prioridade</option>
                                    <option value="alta">alta</option>
                                    <option value="média">média</option>
                                    <option value="baixa">baixa</option>
                                </select>
                            </label>
                        </div>
                        <div className="btn-registrar-filter">
                        <button >Aplicar</button>
                    </div>
                    </div>

                   

                </div>

            </div>

        )
    }

    return null




}
