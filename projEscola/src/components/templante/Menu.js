import './Menu.css';
import React from 'react';
import { Link} from 'react-router-dom';
export default function Menu(props) 
{
    return (
        <nav className='menu'>
            <Link to="/alunos">
                Alunos
            </Link>
            <Link to="/cursos">
                Cursos
            </Link>
            <Link to="/carometro">
                Carômetro
            </Link>
        </nav>
)
}