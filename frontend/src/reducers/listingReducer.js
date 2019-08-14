import { UpdateListing } from '../actions/actionTypes'

const initialState = { listing: {} }

const listingReducer = (state = initialState, action) => {
    switch (action.type) {
        case UpdateListing:
            return { ...state, listing: action.payload }

        default:
            return state
    }
}

export default listingReducer
