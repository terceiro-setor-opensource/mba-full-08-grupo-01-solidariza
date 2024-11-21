import React from "react";
import ReactDOM from "react-dom/client";

import { createBrowserRouter, redirect, RouterProvider } from "react-router-dom";

import AbrigoList from "./Components/abrigo-list/abrigoList.jsx";
import DoadoresList from "./Components/doadores-list/doadoresList.jsx";
import PrivateRoute from "./Components/privateRoute/PrivateRoute.jsx";
import ErrorPage from "./routes/ErrorPage.jsx";
import Home from "./routes/Home.jsx";
import Login from "./routes/Login.jsx";
import SignIn from "./routes/SignIn.jsx";
import Modal from "./Components/modal-abrigo/modalAdd.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: (
      <PrivateRoute>
        <Home />
      </PrivateRoute>
    ),
    children: [
      {
        path: "/doadores-list",
        element: <DoadoresList />,

        
      }, 
      {
        path: "/abrigo-list",
        element: <AbrigoList /> ,
        
      },

      {
        path:"/modal-abrigo",
        element:<Modal/>
      }
  
    ],
  },
  {
    path: "/login",
    loader: async () => {
      if (localStorage.getItem("token")) return redirect("/");
      return null;
    },
    element: <Login />,
  },
  {
    path: "/cadastro",
    element: <SignIn />,
  },
  {
    path: "*",
    element: <ErrorPage />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
