import React from "react";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar"; 
import AllBooks from "./pages/AllBooks"; 
import Search from "./pages/Search";

import Header from "./components/Header";

function App() {
  return (
    <Router>
      <Header></Header>
      <Navbar />
      <Routes>
        <Route path="/" element={<AllBooks />} /> 
        <Route path="/search" element={<Search />} />
      </Routes>
    </Router>
  );
}

export default App;
