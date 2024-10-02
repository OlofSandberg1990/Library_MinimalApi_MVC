import React from 'react';

const DeleteBookModal = ({ isOpen, onClose, onDeleteConfirm }) => {
  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Vill du ta bort boken från biblioteket?</h2>
        <div>
          <button className="close-btn" onClick={onClose}>Nej</button>
          <button className="save-btn" onClick={onDeleteConfirm}>Ja</button>
        </div>
      </div>
    </div>
  );
};

export default DeleteBookModal;
