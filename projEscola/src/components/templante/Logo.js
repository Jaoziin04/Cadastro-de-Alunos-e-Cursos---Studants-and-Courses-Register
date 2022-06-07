import './Logo.css';
import React from 'react';
import logo from '../../assets/imagens/logo_escola.png'

export default function Logo(propos)
{
    return(
        <aside className="logo">
            <a href="/" className="logo">
                <img src={logo} alt="Logo" />
            </a>
        </aside>
    )
}