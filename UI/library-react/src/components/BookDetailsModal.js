import React from 'react';

function BookDetailsModal({ isOpen, onClose, book }) {
  if (!isOpen || !book) return null; //Om modalfönstret inte är öppet eller ingen bok är medskickad så retunera null

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Bokdetaljer</h2>
        <p><strong>Titel:</strong> {book.title}</p>
        <p><strong>Författare:</strong> {book.author}</p>
        <p><strong>Publicerad:</strong> {book.published}</p>
        <p><strong>Genre:</strong> {book.genre}</p>
        <p><strong>Beskrivning:</strong> {book.description}</p>
        <p><strong>Tillgänglig för lån:</strong> {book.avaliableForLoan ? 'Ja' : 'Nej'}</p> {/* Hanterar felstavningen */}
        <button className="close-btn" onClick={onClose}>Stäng</button>
      </div>
    </div>
  );
}

export default BookDetailsModal;
