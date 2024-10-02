import React, { useEffect, useState } from 'react';
import BookDetailsModal from '../components/BookDetailsModal';
import UpdateBookModal from '../components/UpdateBookModal';
import AddBookModal from '../components/AddBookModal';
import DeleteBookModal from '../components/DeleteBookModal';

function AllBooks() {
  const [books, setBooks] = useState([]); //Lista över böckerna som ska hämtas från API:t
  const [loading, setLoading] = useState(true);
  const [selectedBook, setSelectedBook] = useState(null); //Används för att hålla reda på vilken bok man klickar på
  
  //Kollar om de olika modalerna är öppna. Standardvärde sätts till false
  const [isDetailsModalOpen, setIsDetailsModalOpen] = useState(false); 
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);

  //Funktion för att hämta alla böcker från mitt API
  const fetchBooks = async () => {
    try {
      const response = await fetch('https://localhost:7152/api/books');
      const data = await response.json();
      setBooks(data.result);
      setLoading(false);
    } catch (error) {
      console.error('Fel när böcker hämtades:', error);
      setLoading(false);
    }
  };

  //useEffect för att hämta böckerna när sidan laddas
  useEffect(() => {
    fetchBooks();
  }, []);

  //metoder för att hantera när man klickar på knapparna.
  //Här sätts den valda boken man klickar på som SelectedBook och rätt modalfönster öppnas genom att värdet sätts till true
  const handleDetailsClick = (book) => {
    setSelectedBook(book);
    setIsDetailsModalOpen(true);
  };

  const handleUpdateClick = (book) => {
    setSelectedBook(book);
    setIsUpdateModalOpen(true);
  };

  const handleAddBookClick = () => {
    setIsAddModalOpen(true);
  };

  const handleDeleteClick = (book) => {
    setSelectedBook(book);
    setIsDeleteModalOpen(true);
  };

  //Metod för att stänga ner alla öppna modaler och nollställa SelectedBook
  const handleCloseModals = () => {
    setIsDetailsModalOpen(false);
    setIsUpdateModalOpen(false);
    setIsAddModalOpen(false);
    setIsDeleteModalOpen(false);
    setSelectedBook(null);
  };

  const handleBookUpdated = (updatedBook) => {
    //Skapa en ny lista där vi lagrar de uppdaterade böckerna
    const updatedBooksList = books.map((book) => {
      // Om bokens ID matchar den uppdaterade bokens ID, ersätt med den uppdaterade boken
      if (book.bookId === updatedBook.bookId) {
        return updatedBook;
      }
      //Om inte, behåll den gamla boken
      return book;
    });
  
    //Sätt den nya listan som vår nya state för böcker
    setBooks(updatedBooksList);
  };

  //Metod för att uppdatera litsan när en ny bok har lagts till
  const handleBookAdded = () => {
    fetchBooks();
    handleCloseModals();
  };

  //Metod för att hantera borttagningen av en bok
  const handleBookDeleted = async () => {
    
    //Skickar ett DELETE-anrop till apiet för att ta bort den valdra boken genom dess ID
    try {
      await fetch(`https://localhost:7152/api/book/${selectedBook.bookId}`, {
        method: 'DELETE',
      });
      setBooks((prevBooks) => prevBooks.filter((book) => book.bookId !== selectedBook.bookId));
      handleCloseModals();
    } catch (error) {
      console.error('Fel vid borttagning:', error);
    }
  };

  //Visa en enkel indikator för att böckerna laddas 
  if (loading) {
    return <p>Laddar böcker...</p>;
  }

  return (
    <div className="container">
      <div className="header">
        <h1>Alla böcker i biblioteket</h1>
        <button className="add-book-btn" onClick={handleAddBookClick}>Lägg Till Bok</button>
      </div>

      <div className="book-list">
        {books.length === 0 ? (
          <p>Inga böcker hittades.</p> //Om books == 0 så visas detta meddelandet.
        ) : (
          books.map((book) => (
            //Här packar vi upp alla böcker genom .map och tilldelar varje book-card en key som är dess bookId
            <div key={book.bookId} className="book-card"> 
              <div className={`availability-badge ${book.avaliableForLoan ? "available" : "not-available"}`}>
                {book.avaliableForLoan ? "Tillgänglig" : "Ej tillgänglig"}
              </div>
              <div>
                <h3>{book.title}</h3>
                <p>Författare: {book.author}</p>
              </div>
              <div>
                <button className="details" onClick={() => handleDetailsClick(book)}>
                  Visa detaljer
                </button>
                <button className="update" onClick={() => handleUpdateClick(book)}>
                  Uppdatera
                </button>
                <button className="delete" onClick={() => handleDeleteClick(book)}>
                  <i className="fas fa-trash"></i>
                </button>
              </div>
            </div>
          ))
        )}
      </div>

      <BookDetailsModal
        isOpen={isDetailsModalOpen} //Visas endast om detta är true
        onClose={handleCloseModals} //Funktion för att stänga modalfönstret
        book={selectedBook} //Skickar med den valda boken till modalen
      />

      <UpdateBookModal
        isOpen={isUpdateModalOpen}
        onClose={handleCloseModals}
        book={selectedBook}
        onBookUpdated={handleBookUpdated}
      />

      <AddBookModal
        isOpen={isAddModalOpen}
        onClose={handleCloseModals}
        onBookAdded={handleBookAdded}
      />

      <DeleteBookModal
        isOpen={isDeleteModalOpen}
        onClose={handleCloseModals}
        onDeleteConfirm={handleBookDeleted}
      />
    </div>
  );
}

export default AllBooks;
