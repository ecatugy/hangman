import React, { useState, useEffect, Fragment } from "react";
import { GAME_STARTED, GAME_WON, GAME_OVER } from "../../constants";
import { gameFactory } from "../../lib/Game";
import axios from "axios";
import { Game } from "../ui";

export const App = () => {
  const [data, setData] = useState({
    words: [],
    isLoading: true,
    stateGame: {}
  });

  const onRestartClick = e => {
    e.preventDefault();
    setData({
      ...data,
      stateGame: gameFactory(data.words)
    });
  };

  const onLetterClick = letter => {
    const firstIndex = data.stateGame.word.indexOf(letter);
    if (firstIndex !== -1) {
      const letters = data.stateGame.letters.map(letterObject => {
        if (letterObject.value === letter) {
          return Object.assign({}, letterObject, {
            guessed: true
          });
        }
        return letterObject;
      });

      // Check if the game has been won
      const gameWon = letters.reduce((winState, currentObject) => {
        return winState && currentObject.guessed;
      }, true);

      setData({
        ...data,
        stateGame: {
          ...data.stateGame,
          ...{
            letters: letters,
            pastGuesses: [letter].concat(data.stateGame.pastGuesses),
            gameState: gameWon ? GAME_WON : GAME_STARTED
          }
        }
      });
    } else {
      // Update number of attempts left
      const guessesLeft = data.stateGame.guesses - 1;
      let stateUpdate = {
        guesses: guessesLeft
      };

      // Kill the game if needed
      if (guessesLeft === 0) {
        stateUpdate.gameState = GAME_OVER;
      }

      // Update the letters already tried
      stateUpdate.pastGuesses = [letter].concat(data.stateGame.pastGuesses);

      setData({
        ...data,
        stateGame: { ...data.stateGame, ...stateUpdate }
      });
    }
  };

  useEffect(() => {
    (async () => {
      const result = await axios(process.env.REACT_APP_API_WORD);
      setData({
        words: result.data,
        loading: false,
        stateGame: gameFactory(result.data)
      });
    })();
  }, []);

  return (
    <Fragment>
      {data.isLoading ? (
        <div>Loading ...</div>
      ) : (
        <Game
          onLetterClick={onLetterClick}
          onRestartClick={onRestartClick}
          stateGame={data.stateGame}
        />
      )}
    </Fragment>
  );
};
