import React, { useState } from "react";

function SearchBook() {

  //state-variablar för att hålla koll på söksträngen, lagrar böcker som matchar sökningen, hålla koll på om sökningen pågår och eventuella felmeddelanden
  const [searchTerm, setSearchTerm] = useState("");
  const [books, setBooks] = useState([]);
  const [loading, setLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState(null);

  //Hanterar själva sökningen. Sätter igång loading och tömmer error messages
  const handleSearch = async () => {
    setLoading(true);
    setErrorMessage(null);
    try {
      const response = await fetch(`https://localhost:7152/api/book/title/${searchTerm}`);
      if (!response.ok) {
        setErrorMessage(`Din sökning efter "${searchTerm}" kunde inte hittas i biblioteket. Försök igen.`); //Meddelande om ingen bok kunde hittas i databasen
        setBooks([]); //Tömmer boklistan om inget hittas
      } else {
        const data = await response.json();
        if (data.result.length === 0) {
          setErrorMessage(`Din sökning efter "${searchTerm}" kunde inte hittas i biblioteket. Försök igen.`); // Om inget hittas
          setBooks([]); //Tömmer boklistan om inget hittas
        } else {
          setBooks(data.result);// Spara de böcker som returneras från API:et
        }
      }
      setLoading(false);
    } catch (err) {
      setErrorMessage("Ett fel uppstod vid sökning");
      setLoading(false);
    }
  };

  return (
    <div className="container">
      <h1>Sök efter bok</h1>
      <div className="search-bar">
        <input
          type="text"
          placeholder="Ange boktitel"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Sök</button>
      </div>
      {loading && <p>Laddar...</p>}
      {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
      {books.length > 0 && (
        <div className="book-list">
          {books.map((book) => (
            <div key={book.bookId} className="book-card">
              <h3>{book.title}</h3>
              <p>Författare: {book.author}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default SearchBook;
