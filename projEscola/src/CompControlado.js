import React, {useState} from 'react';

export default function CompControlado()
{

    const[nome, setNome] = useState("nomeInicial");


    function leNome(evento)
    {
       //console.log(evento.target.value)
       SetNome(evento.target.value)
    }

    function exibeNome()
    {
        alert(nome)
    }

    return
    (
        <div style={{fontFamily: 'Verdana'}}>
            
            <h1>Exemplo Componente Controlado</h1>

            <label>
                Nome:
                <input type="text" onChange={letNome} />
            </label>
        </div>
    )
}