import { GAME_STARTED } from '../../constants';


 const randomWord = words => {
  const wordIndex = Math.floor(Math.random() * words.length);
  return words[wordIndex].name;
}


export const gameFactory = (words) => {
    const gameWord = randomWord(words);
    return {
      word: gameWord,
      letters: gameWord.split('').map(letter => ({
        value: letter.toLocaleUpperCase(),
        guessed: false,
      })),
      guesses: 5,
      gameState: GAME_STARTED,
      pastGuesses: [],
    };
  };


