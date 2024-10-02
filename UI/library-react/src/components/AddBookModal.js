import React, { useState } from 'react';

//Först skapar vi lite variablar för att hålla den inmatade datan
const AddBookModal = ({ isOpen, onClose, onBookAdded }) => {
  const [newTitle, setNewTitle] = useState('');
  const [newAuthor, setNewAuthor] = useState('');
  const [newPublished, setNewPublished] = useState('');
  const [newGenre, setNewGenre] = useState('');
  const [newDescription, setNewDescription] = useState('');
  const [newAvaliableForLoan, setNewAvaliableForLoan] = useState(true);

  const handleSave = async () => {
    if (!newTitle.trim() || !newAuthor.trim()) {
      return; //Grundläggande validering att title och författare är med
    }

    try {
      const response = await fetch('https://localhost:7152/api/book', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          title: newTitle,
          author: newAuthor,
          published: parseInt(newPublished),
          genre: newGenre,
          description: newDescription,
          avaliableForLoan: newAvaliableForLoan
        }),
      });

      if (response.ok) {
        const newBook = await response.json(); //Här får vi den nyskapade boken som svar från apiet
        onBookAdded(newBook);  //Lägger till boken i listan...
        onClose();  //...och sedan stänger modalen
      }
    } catch (error) {
      console.error('Fel vid sparande:', error);
    }
  };

  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Lägg till ny bok</h2>

        <label htmlFor="title">Titel</label>
        <input
          type="text"
          id="title"
          value={newTitle}
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
          type="text"
          id="published"
          value={newPublished}
          onChange={(e) => setNewPublished(e.target.value)} // Uppdatera publiceringsår
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

export default AddBookModal;
