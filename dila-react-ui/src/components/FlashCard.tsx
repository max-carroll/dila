import React from "react";
import { TextField, Chip, FormControl, InputLabel, Select, MenuItem, Button } from '@material-ui/core'
import Autocomplete from '@material-ui/lab/Autocomplete';
import Picker from 'emoji-picker-react'
import axios from 'axios';

enum WordType {
  Noun = "Noun",
  Verb = "Verb",
  Adjective = "Adjective",
  Adverb = "Adverb",
  Pronoun = "Pronoun"
}

enum Language {
  English = "English",
  Tagalog = "Tagalog"
}

class Word {
  id: number = 0
  name: string = ""
  translation: string = ""
  language: Language = Language.Tagalog
  categories: Category[] = []
  type?: WordType | null | undefined = null
  emoji?: string | null | undefined = null
}

class Category {
  id: number = 0
  name: string = ""
}


export function FlashCard() {

  const [word, setWord] = React.useState<Word>(new Word())

  const cats : Category[] = [ {id: 1, name: "kitchen"}, {id: 2, name: "money"}]

  const handleCurriedChange = (name: string) => (event: any) => {
    const { value } = event.target
    setWord((old) => ({ ...old!, [name]: value }))
  }

  const setCategories = (event: any, values: (string | Category)[]) => {

    const catValues = values as Category[]

    setWord(old => ({ ...old!, categories: catValues }))
  }

  const onEmojiClick = (event : any, emojiObject : any) => {
    setWord(old => ({ ...old!, emoji: emojiObject.emoji }))
  };

  const handleSaveWord = async () => {

    await axios.post("http://localhost:32771/api/word", word )

  }


  return (
    <>
      <TextField
        label="name"
        id="name"
        value={word?.name}
        helperText="e.g. Hello"
        onChange={handleCurriedChange('name')}
      />
      <TextField
        label="translation"
        id="translation"
        helperText="e.g. Bonjour"
        value={word?.translation}
        onChange={handleCurriedChange('translation')}
      />
      <FormControl>
        <InputLabel htmlFor="language">Language</InputLabel>
        <Select
          value={word?.language}
          onChange={handleCurriedChange("language")}
        >
          {Object.values(Language).map(t => <MenuItem value={t}>{t}</MenuItem>)}

        </Select>
      </FormControl>

      {/* Categories */}
      <Autocomplete
        multiple
        value={word.categories}
        options={cats}
        freeSolo
        id="categories"
        onChange={setCategories}
        getOptionLabel={ (c : Category) => c.name }
        
        renderTags={(value, getTagProps) =>
          value?.map((option, index) => (
            <Chip
              key={index}
              label={option.name}
              size="small"
              //   className={classes.chip}
              {...getTagProps({ index })}
            />
          ))
        }
        renderInput={(params) => (
          <TextField {...params} label={"categoires"} />
        )}
      />

      {/* Word type adjective, noun, verb etc... */}
      <FormControl>
        <InputLabel htmlFor="type">type</InputLabel>
        <Select
          value={word?.type}
          onChange={handleCurriedChange("type")}
        >
          {
            Object.values(WordType).map(t => <MenuItem value={t}>{t}</MenuItem>)
          }
        </Select>
      </FormControl>

      {/* EMOJI PICKER */}

      <TextField
        label="emoji"
        id="emoji"
        // Some emojis are more than 1 in length
        // inputProps={{maxLength : 1}} 
        value={word?.emoji ?? ""}
        onChange={handleCurriedChange('emoji')}
      />
      {/* <Picker onEmojiClick={onEmojiClick} /> */}


      {/* Record sound */}

      {/* Pictures upload */}

      <Button
      onClick={handleSaveWord}
      >Save Word!</Button>

    </>

  )
};