import React from 'react';

const styles = {
    character: {
        fill: 'none',
        stroke: 'black',
        strokeWidth: 3,
    },
    post: {
        fill: 'none',
        stroke: 'black',
        strokeWidth: 10,
    },
};


export const  Hangman = (props) => {
    
    const renderHead = () => {
        return props.body
            ? <circle cx="320" cy="190" r="40" fill="black" />
            : null;
    }


    const renderBody = () => {
        return props.body
            ? <line x1="320" y1="190" x2="320" y2="360" style={styles.character} />
            : null;
    }


    const renderLeftArm = () => {
        return props.leftArm
            ? <line x1="320" y1="260" x2="250" y2="230" style={styles.character} />
            : null;
    }


    const renderRightArm = () => {
        return props.rightArm
            ? <line x1="320" y1="260" x2="390" y2="230" style={styles.character} />
            : null;
    }


    const renderLeftLeg = () => {
        return props.leftLeg
            ? <line x1="320" y1="360" x2="250" y2="450" style={styles.character} />
            : null;
    }


    const renderRightLeg = () => {
        return props.rightLeg
            ? <line x1="320" y1="360" x2="390" y2="450" style={styles.character} />
            : null;
    }
    return (
        <svg width="500" height="550">
            <polyline points="400,500 100,500 150,500 150,100 320,100 320,150"
                style={styles.post} />
            {renderBody()}
            {renderLeftArm()}
            {renderRightArm()}
            {renderLeftLeg()}
            {renderRightLeg()}
            {renderHead()}
        </svg>
    );
}
