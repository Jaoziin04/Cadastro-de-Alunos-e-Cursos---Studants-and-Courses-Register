import React from 'react';
import{Routes, Route} from "react-router-dom";

import Main from './components/templante/Main';
import CrudAluno from './components/GrudAluno';
import CrudCurso from './components/GrundCurso';

export default function Rotas() 
{
    return  (
            <Routes>
                <Route exact path='/'
                element={
                    <Main title="Bem Vindo!">
                    <div>Cadastro de alunos, cursos e carômetro</div>
                    </Main>}
                />
                <Route path='/alunos' element={<CrudAluno />} />
                <Route path="*" to='/'/>
                <Route path='/cursos' element={<CrudCurso />} />
                <Route path="*" to='/'/>
            </Routes>
            )
}