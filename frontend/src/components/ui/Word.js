import React from 'react';
import '../../stylesheets/word.css'

export const Word = props => {
    return (
        <div className="Word">
            {props.children}
        </div>
    );
}
