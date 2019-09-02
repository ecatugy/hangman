
import React from 'react';
import '../../stylesheets/letterBlock.css';

export const LetterBlock = (props) => {
    return (
        <div onClick={props.onClick} className="LetterBlock">
          <span>
            {props.value}
          </span>
        </div>
      );
  
}
