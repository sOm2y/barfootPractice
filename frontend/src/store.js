import { createStore, combineReducers } from 'redux'
import authReducer from './reducers/authReducer'

const rootReducer = combineReducers({
    authReducer: authReducer
})

export default createStore(rootReducer);