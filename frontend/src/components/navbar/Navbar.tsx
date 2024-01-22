import { Menu } from "@mui/icons-material"
import { Link } from "react-router-dom"
import './navbar.scss'


const Navbar: React.FC = () => {
    return (
        <div className="navbar">
        <div className="brand">Toscana</div>
            <div className="hamburguer">
                <Menu />

            </div>
            <div className="menu">
                <ul>
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/usuario">Usuarios</Link></li>
                    <li><Link to="/usuario/add">Add Usuarios</Link></li>
                    <li><Link to="/destino">Destinos</Link></li>
                    <li><Link to="/destino/add">Add Destinos</Link></li>
                    <li><Link to="/destinoReservado">Destinos Reservados</Link></li>
                    <li><Link to="/destinoReservado/add">Add Destinos Reservados</Link></li>
                </ul>
            </div>
        </div>
    )
}

export default Navbar