import React from "react";
import "./Header.css"; //Separat css för headern

function Header() {
  return (
    <header className="app-header">
      <h1>Bibliotek Skapat i React</h1>
      <p>En skoluppgift om att koppla API till frontend</p>
    </header>
  );
}

export default Header;
