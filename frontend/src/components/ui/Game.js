import React from 'react';
import '../../stylesheets/game.css'
import {Hangman, RestartButton, VirtualKeyboard, AttemptsLeft, Word, Letter} from '../ui'
import { GAME_WON, GAME_OVER } from '../../constants'


const hangmanAttempts = (attemptsLeft) => {
  let props = {
    body: attemptsLeft <= 4,
    leftArm: attemptsLeft <= 3,
    rightArm: attemptsLeft <= 2,
    leftLeg: attemptsLeft <= 1,
    rightLeg: attemptsLeft === 0,
  };

  return <Hangman {...props} />
}

export const Game = (props) => {
  const renderInputPanel = () => {
    const hasAttemptsLeft = props.stateGame.guesses > 0;
    const gameWon = props.stateGame.gameState === GAME_WON;
    const content = hasAttemptsLeft
      ? gameWon
        ? renderGameFinished('Congrats! 🤗 🏆 🤗', 'Game-GameWin')
        : (
          <div className="Game-VirtualKeyboard">
            <VirtualKeyboard
              excluded={props.stateGame.pastGuesses}
              onClick={props.onLetterClick}
            />
          </div>
        )
      : renderGameFinished('GAME OVER ☠️', 'Game-GameOver');

    return (
      <div className="Game-InputPanel">
        {renderWord()}
        <div className="Game-AttemptsLeft">
          <AttemptsLeft attempts={props.stateGame.guesses} />
        </div>
        {content}
      </div>
    );
  }


  const renderGameFinished = (message, cssClass) => {
    return (
      <div className={cssClass}>
        <span>{message}</span>
        <RestartButton
          onClick={props.onRestartClick}
          gameState={props.stateGame}
        />
      </div>
    )
  }

  const renderWord = ()=> {
    return (
      <div className="Game-Word">
        <Word>
          {props.stateGame.letters.map((letter, i) => {
            const letterValue = (
              props.stateGame.gameState === GAME_OVER || letter.guessed
            ) ? letter.value : '_';

            return (
              <Letter
                key={`word-letter-${i}`}
                value={letterValue}
              />
            );
          })}
        </Word>
      </div>
    );
  }

  return (
    <div className="Game-content">
      <div className="Game-SideBySide">
        {renderInputPanel()}
        <div className="Game-Hangman">
          {hangmanAttempts(props.stateGame.guesses)}
        </div>
      </div>
    </div>
  );
}
