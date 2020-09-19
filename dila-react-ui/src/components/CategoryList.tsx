import React from "react";
import { TextField, Chip, FormControl, InputLabel, Select, MenuItem, Button } from '@material-ui/core'
import Autocomplete from '@material-ui/lab/Autocomplete';
import Picker from 'emoji-picker-react'
import axios, { AxiosResponse } from 'axios';
import { Word } from "../models/";
import { DisplayJson } from "./DisplayJson";



export function CategoryList() {

  const [words, setWords] = React.useState<Word[]>(new Array<Word>())

  React.useEffect(()=> {
    async function fetch(){
      var result = await axios.get<any, AxiosResponse<Word[]>>("http://localhost/api/word")
      setWords(result?.data)
    }
    fetch()
  },[])


  return (
    <>
        {
            words && words.map(w=> <DisplayJson object={w}></DisplayJson>)
        }
        
    </>

  )
};

