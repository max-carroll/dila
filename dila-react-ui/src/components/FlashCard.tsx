import React from "react";
import { TextField, Chip, FormControl, InputLabel, Select, MenuItem } from '@material-ui/core'
import Autocomplete from '@material-ui/lab/Autocomplete';

enum Language {
    English = "English",
    Tagalog = "Tagalog"
}

class Word {
    name: string = ""
    translation: string = ""
    language : Language = Language.Tagalog
    categories : string[] = []
}


export function FlashCard() {

    const [word, setWord] = React.useState<Word>(new Word())

    const cats = ["kitchen", "money", "sports"]

    const handleCurriedChange = (name: string) => (event: any) => {
        const { value } = event.target
        setWord((old) => ({ ...old!, [name]: value }))
    }

    const setCategories =(event: any, values : string[]) => {
        setWord(old => ({...old!, categories: values}))
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
                <MenuItem value={Language.English}>{Language.English}</MenuItem>
                <MenuItem value={Language.Tagalog}> {Language.Tagalog}</MenuItem> 
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
                // label="Categories"
                renderTags={(value, getTagProps) =>
                  value?.map((option, index) => (
                    <Chip
                      key={index}
                      //variant="outlined"
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

            {/* EMOJI PICKER */}

            {/* Record sound */}

            {/* Pictures upload */}
            
        </>

    )
};