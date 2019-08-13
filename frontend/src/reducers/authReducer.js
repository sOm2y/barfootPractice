import { UpdateCurrentUser } from '../actions/actionTypes'

const initialState = { isAuthenticated: false, user: {}}

const authReducer = (state = initialState, action) => {
    switch (action.type) {
        case UpdateCurrentUser:
            return { ...state, isAuthenticated: true, user: action.payload }

        default:
            return state
    }
}

export default authReducer
