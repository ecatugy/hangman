import { GAME_STARTED } from '../../constants';
import axios from "axios";
import INITIAL from '../../data/initial.json'


const randomWord = words => {
  const wordIndex = Math.floor(Math.random() * words.length);
  return words[wordIndex].name;
}


const  getBoolean=(value)=>{
  switch(value){
       case true:
       case "true":
       case 1:
       case "1":
       case "on":
       case "yes":
           return true;
       default: 
           return false;
   }
}

export const getInitialState = async () => {
  var result = INITIAL;
  if (getBoolean(process.env.REACT_APP_GET_ONLINE))
    result = await axios(process.env.REACT_APP_API_WORD);
  return result;
};

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


