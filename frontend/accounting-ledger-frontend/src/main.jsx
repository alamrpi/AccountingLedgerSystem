import React from 'react'
import { BrowserRouter } from 'react-router-dom'
import { NotificationProvider } from './contexts/NotificationContext'
import { createRoot } from 'react-dom/client'
import './index.css'
import AppRouter from './routes/AppRouter.jsx'

createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
    <NotificationProvider>
      <AppRouter />
    </NotificationProvider>
    </BrowserRouter>
  </React.StrictMode>,
)
