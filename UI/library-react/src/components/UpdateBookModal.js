import React, { useState, useEffect } from 'react';

//Deklarerar state-variablar för att lagra de uppdaterade fälten. Standardvärde sätts som tomt.
const UpdateBookModal = ({ isOpen, onClose, book, onBookUpdated }) => {
  const [newTitle, setNewTitle] = useState('');
  const [newAuthor, setNewAuthor] = useState('');
  const [newPublished, setNewPublished] = useState('');
  const [newGenre, setNewGenre] = useState('');
  const [newDescription, setNewDescription] = useState('');
  const [newAvaliableForLoan, setNewAvaliableForLoan] = useState(true);

  //Här används useEffect för att fylla i formuläret med den befintliga datan innan uppdateringen.
  useEffect(() => {
    if (book) {
      setNewTitle(book.title);
      setNewAuthor(book.author);
      setNewPublished(book.published);
      setNewGenre(book.genre);
      setNewDescription(book.description);
      setNewAvaliableForLoan(book.avaliableForLoan);
    }
  }, [book]);

  const handleSave = async () => {
    if (!newTitle.trim() || !newAuthor.trim()) {
      return; //Grundläggande validering för att kolla så att inte titel och författar lämnas tomt
    }

    //Anropar API:ets endpoint för att uppdatera boken
    try {
      const response = await fetch(`https://localhost:7152/api/book/${book.bookId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          bookId: book.bookId,
          title: newTitle,
          author: newAuthor,
          published: parseInt(newPublished), //Parsar publiceringsåret till en int
          genre: newGenre,
          description: newDescription,
          avaliableForLoan: newAvaliableForLoan
        }),
      });

      //Om API-anropet lyckades skapar vi en uppdaterad bok och skickar tillbaka den med de uppdaterade värderna
      if (response.ok) {
        const updatedBook = { ...book, //Behåller de existerande fält som inte ändras
          title: newTitle, 
          author: newAuthor, 
          published: newPublished, 
          genre: newGenre, 
          description: newDescription, 
          avaliableForLoan: newAvaliableForLoan };
        onBookUpdated(updatedBook);  //Skickar tillbaka den uppdaterade boken
        onClose();  //Stänger modalen igen
      }
      //Loggar eventuella fel vid hämtningen
    } catch (error) {
      console.error('Fel vid uppdatering:', error);
    }
  };

  //Om modalfönsret inte är öppen eller ingen bok är vald så ska ingenting renderas.
  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Uppdatera bok</h2>
        
        <label htmlFor="title">Titel</label>
        <input
          type="text"
          id="title"
          value={newTitle}
          //Här skickas den nya titeln och sätts med setNewTitle
          onChange={(e) => setNewTitle(e.target.value)}
        />
        
        <label htmlFor="author">Författare</label>
        <input
          type="text"
          id="author"
          value={newAuthor}
          onChange={(e) => setNewAuthor(e.target.value)}
        />
        
        <label htmlFor="published">Publiceringsår</label>
        <input
          type="number"
          id="published"
          value={newPublished}
          onChange={(e) => setNewPublished(e.target.value)}
        />

        <label htmlFor="genre">Genre</label>
        <input
          type="text"
          id="genre"
          value={newGenre}
          onChange={(e) => setNewGenre(e.target.value)}
        />

        <label htmlFor="description">Beskrivning</label>
        <textarea
          id="description"
          value={newDescription}
          onChange={(e) => setNewDescription(e.target.value)}
        />

        <label htmlFor="avaliableForLoan">Tillgänglig för lån</label>
        <input
          type="checkbox"
          id="avaliableForLoan"
          checked={newAvaliableForLoan}
          onChange={(e) => setNewAvaliableForLoan(e.target.checked)}
        />

        <div>
          <button className="close-btn" onClick={onClose}>Stäng</button>
          <button className="save-btn" onClick={handleSave}>Spara</button> 
        </div>
      </div>
    </div>
  );
};

export default UpdateBookModal;
