import { createStore, combineReducers } from 'redux'
import authReducer from './reducers/authReducer'
import listingReducer from './reducers/listingReducer'
import staffReducer from './reducers/staffReducer';

const rootReducer = combineReducers({
    authReducer: authReducer,
    listingReducer: listingReducer,
    staffReducer: staffReducer
})

export default createStore(rootReducer);