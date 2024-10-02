import React from "react";
import { Link } from "react-router-dom"; // Importerar Link från react-router-dom
import "./Navbar.css" //En separat CSS-fil för att styla just navbaren

function Navbar() {
  return (
    <nav className="navbar">
      <ul>
        <li><Link to="/">Biblioteket</Link></li>
        <li><Link to="/search">Sök efter bok</Link></li>  
      </ul>
    </nav>
  );
}

export default Navbar;
