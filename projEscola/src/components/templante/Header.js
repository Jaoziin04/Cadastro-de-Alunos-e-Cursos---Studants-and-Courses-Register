import './Header.css';
import React from 'react';

export default function Header(propos)
{
    return(
        <header className="header">
            <h2>{propos.title}</h2>
        </header>
    )
}