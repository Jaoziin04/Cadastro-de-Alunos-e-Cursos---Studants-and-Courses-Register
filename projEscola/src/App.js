import './App.css';
import Logo from './components/templante/Logo';
import Menu from './components/templante/Menu';
import Footer from './components/templante/Footer';
import Rotas from './Rotas';
import { BrowserRouter } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
          <Logo />
          <Menu />
          <Rotas />
          <Footer />
      </div>
    </BrowserRouter>
  );
} 

export default App;
