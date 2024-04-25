# FINAL COUNTDOWN

A react project to create a game of final countdown in _ReacJS_.
ReactJs can use to simplify the game using useRef, useImperativeHandle, forwardRef.
Create a modal with CreatePortal.

Play the game **final countdown**

## Components

-   Player
-   Result Modal
-   Timer Challenge

## Tech Stack

**Client:** ReactJs, Eslint, Prettier

[![js-standard-style](https://img.shields.io/badge/code%20style-standard-brightgreen.svg)](http://standardjs.com)

## Challenges

-   User input with State (two way binding)
-   Using Fragments
-   Refs - accessing HTML Elements via Refs
-   Manipulating the DOM via Refs
-   Refs vs State Values
-   Fowarding Refs
-   useImperativeHandleHook
-   Exposing component APIs
-   Add Result modal
-   ESC (escape) key
-   Understand Portals

## Run Locally

Clone the project

```bash
  git clone https://github.com/horcas1976/final-countdown
```

Go to the project directory

```bash
  cd final-countdown
```

Install dependencies

```bash
  npm install
  npm install --save-dev eslint eslint-config-standard
  npm install --save-dev eslint-config-prettier
```

````
Build locally

```bash
  npm run build
````

Check linting

```bash
  npm run lint
```

Start the server locally

```bash
  npm run dev
```

## Usage/Examples

### Index.html

```HTML
<div id="modal"></div>
<div id="root"></div>
```

### App.jsx

```javascript
export default function App () {
return (
    <>
      <Player />
      <div id='challenges'>
        <TimerChallenge title='Easy' targetTime={1} />
        <TimerChallenge title='Not Easy' targetTime={5} />
        <TimerChallenge title='Getting tough' targetTime={10} />
        <TimerChallenge title='Pros only' targetTime={15} />
      </div>
    </>
  );
```

# Hi, I'm Horcas21! 👋

## 🚀 About Me

I'm a full stack developer.
_Client side_: ReactJS. ASP.NET, MVC and .NET Core.
_Server side_: Express, .NET and microservices.

## 🛠 Skills

#### **Scrum methodology**

-   Planning. Refinement. Define Story points. Demo. Retrospective

#### **Architecture**

-   Layer, Microservices and MVC

#### **Repository**

-   SVN, GIT and TFS

#### **Tracking tasks**

-   JIRA, TFS, Confluence, WIKI

#### **IDE**

-   Visual Studio 2017/2019/2022
-   Visual Code

#### **Database**

-   MS SQL Server, mySQL, postgreSQL and Oracle

#### **Development**

-   _Client side_: ReactJS, NodeJs, HTML, Javascript, CSS, Jquery UI, Dynamo DB, ESLint, Prettier, Flex, Module CSS.
-   _Server side_: Express, C#, .NET MVC, .NET Core, .NET WebAPI.
-   _Database_: SQL Server and MongoDB.
-   _AWS_: Cloudfront, Cloudwatch, S3 Bucket
-   _Logging_: ServiceLogger
-   _Testing_: Microsoft.VisualStudio.TestTools.UnitTesting, xUnit and Jest ins ReactJS

## 🔗 Links

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/ariel-h%C3%BCnicken-21387038//)

## Related

This template provides a minimal setup to get React working in Vite.

```bash
  npm create vite@latest my-react-app -- --template react
```

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

-   [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react/README.md) uses [Babel](https://babeljs.io/) for Fast Refresh
-   [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh
