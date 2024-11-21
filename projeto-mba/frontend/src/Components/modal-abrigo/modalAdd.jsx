import "./modalAdd.css"
import imagen from "../../assets/tl.png"
import React from 'react'

export default function Modal({ isOpen, setOpenModal, openModal}) {

    if (isOpen) {
        return (

            <div className="background-modal">
                <div className="conteudo-modal">
                    <div className="content-tittle">
                        <div className="header-modal">
                            <h2 className="tittle-modal">NOVO PRODUTO</h2>
                            <p onClick={setOpenModal} className="subtittle-modal">x</p>
                        </div>
                    </div>
                    <div className="content-imagen-modal">
                        <img className="imagen-modal" src={imagen} alt="" />
                    </div>
                    <div className="info-modal">
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
                        <div className="btn-registrar">
                        <button >Registrar</button>
                    </div>
                    </div>

                   

                </div>

            </div>

        )
    }

    return null




}
