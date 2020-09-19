import Language from "../constants/Language";
import WordType from "../constants/WordType";
import Category from "./Category";


export default class Word {
  id: number = 0;
  name: string = "";
  translation: string = "";
  language: Language = Language.Tagalog;
  categories: Category[] = [];
  type?: WordType | null | undefined = null;
  emoji?: string | null | undefined = null;
}
