import React from "react";
import { TextField, Chip, FormControl, InputLabel, Select, MenuItem } from '@material-ui/core'
import Autocomplete from '@material-ui/lab/Autocomplete';
import Picker from 'emoji-picker-react'


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
  name: string = ""
  translation: string = ""
  language: Language = Language.Tagalog
  categories: string[] = []
  type?: WordType | null | undefined = null
  emoji?: string | null | undefined = null
}


export function FlashCard() {

  const [word, setWord] = React.useState<Word>(new Word())

  const cats = ["kitchen", "money", "sports"]

  const handleCurriedChange = (name: string) => (event: any) => {
    const { value } = event.target
    setWord((old) => ({ ...old!, [name]: value }))
  }

  const setCategories = (event: any, values: string[]) => {
    setWord(old => ({ ...old!, categories: values }))
  }

  const onEmojiClick = (event : any, emojiObject : any) => {
    setWord(old => ({ ...old!, emoji: emojiObject.emoji }))
  };


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
        renderTags={(value, getTagProps) =>
          value?.map((option, index) => (
            <Chip
              key={index}
              label={option}
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

    </>

  )
};