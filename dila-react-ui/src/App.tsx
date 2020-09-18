import React from 'react';
import logo from './logo.svg';
import './App.css';
import { FlashCard } from './components/FlashCard';
import { Drawer, makeStyles } from '@material-ui/core';

const drawerWidth = 240;

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
      <Drawer
       className={classes.drawer}
       classes={{
        paper: classes.drawerPaper,
      }}
      variant="permanent" anchor="left">
        Timmy
      </Drawer>
      <main className={classes.content}>
      <FlashCard />
      </main>
    </>
  );
}

export default App;
