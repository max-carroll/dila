import React from 'react';
import logo from './logo.svg';
import './App.css';
import { FlashCard } from './components/FlashCard';
import { Drawer, Grid, makeStyles } from '@material-ui/core';
import { BrowserRouter, Switch, Route, Link } from 'react-router-dom'
import { CategoryList } from './components/CategoryList';

const drawerWidth = 240;

const PATH = {
  NEW_FLASHCARD: "/new-flashcard",
  WORD_LIST: "/word-list"
}

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
  },
  appBar: {
    width: `calc(100% - ${drawerWidth}px)`,
    marginLeft: drawerWidth,
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
  },
  // necessary for content to be below app bar
  toolbar: theme.mixins.toolbar,
  content: {
    position: 'relative',
    left: drawerWidth,
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
}));


function App() {

  var classes = useStyles()
  return (
    <>
      <BrowserRouter>
        <Drawer
          className={classes.drawer}
          classes={{
            paper: classes.drawerPaper,
          }}
          variant="permanent" anchor="left">
          <Grid xs={12} >
            <Link to={PATH.NEW_FLASHCARD}>New Flashcard</Link>
          </Grid>
          <Grid xs={12}>
            <Link to={PATH.WORD_LIST}>Word List</Link>
          </Grid>
        </Drawer>
        <main className={classes.content}>
          <Switch>
            <Route path={PATH.NEW_FLASHCARD}>  <FlashCard /></Route>
            <Route path={PATH.WORD_LIST}>  <CategoryList /></Route>


          </Switch>

        </main>
      </BrowserRouter>
    </>
  );
}

export default App;
