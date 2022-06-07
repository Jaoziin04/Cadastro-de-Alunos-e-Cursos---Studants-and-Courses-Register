import './Main.css';
import React  from 'react';
import Header from './Header';

export default function Main(propos)
{
    return(
        <div className="content">
            <Header {...propos} />
            <main>
                <div>
                    {propos.children}
                </div>
            </main>
        </div>
       
    )
}