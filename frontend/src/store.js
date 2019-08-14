import { createStore, combineReducers } from 'redux'
import authReducer from './reducers/authReducer'
import listingReducer from './reducers/listingReducer'

const rootReducer = combineReducers({
    authReducer: authReducer,
    listingReducer: listingReducer
})

export default createStore(rootReducer);