import { UpdateStaff } from '../actions/actionTypes'

const initialState = { staff: {} }

const staffReducer = (state = initialState, action) => {
    switch (action.type) {
        case UpdateStaff:
            return { ...state, staff: action.payload }

        default:
            return state
    }
}

export default staffReducer
